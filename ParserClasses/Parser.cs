using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PuppeteerExtraSharp;
using PuppeteerExtraSharp.Plugins.AnonymizeUa;
using PuppeteerExtraSharp.Plugins.ExtraStealth;
using PuppeteerSharp;

namespace AutoRuScrapper.ParserClasses
{
    public class Parser
    {
        private readonly string _baseUrl;
        private readonly Dictionary<string, string> _headers;
        private readonly CookieParam[] _cookies;

        private readonly string _url;
        private bool _isBrowserOpen;

        Browser browser;
        Page page;


        public Parser(string baseUrl)
        {
            _baseUrl = baseUrl;
            //_headers = headers;
            //_cookies = cookies;
        }

        public async Task RunAsync()
        {

            if (_isBrowserOpen)
            {
                page = await browser.NewPageAsync();
            }
            else
            {
                browser = await GetBrowserAsync();
                page = await browser.NewPageAsync();
            }


            await page.SetUserAgentAsync("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            //await page.SetExtraHttpHeadersAsync(_headers);
            // await page.SetCookieAsync(_cookies);

            // await page.GoToAsync(_baseUrl);



            #region Куки и заголовки

            // Установка кук
            //var cookies = new List<PupeTest.CookieParam>
            //{
            //    new PupeTest.CookieParam
            //    {
            //    Name = "myCookie",
            //    Value = "myValue",
            //    Domain = "example.com",
            //    Path = "/",
            //    HttpOnly = true,
            //    Secure = true,
            //    Expires = Convert.ToDouble(DateTime.Now.AddDays(1)),
            //    SameSite = SameSiteMode.None
            //    }
            //};
            //await CookiesHelper.SetCookiesAsync(page, cookies);

            //// Установка заголовков
            //var headers = new Dictionary<string, string>
            //{
            //    { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299" }
            //};
            //await HeadersHelper.SetHeadersAsync(page, headers);

            #endregion

            await page.GoToAsync(_baseUrl);

            await CheckForCaptchaAsync(page);

            await page.WaitForTimeoutAsync(2000);

            await page.WaitForNavigationAsync();
            await page.WaitForSelectorAsync(".Button.Button_color_blue.Button_size_m.Button_type_button.Button_width_full");
            var bnt = await page.QuerySelectorAsync(".Button.Button_color_blue.Button_size_m.Button_type_button.Button_width_full");
            await page.HoverAsync(".Button.Button_color_blue.Button_size_m.Button_type_button.Button_width_full");
            await bnt?.ClickAsync();

            var response = await page.WaitForResponseAsync("https://auto.ru/-/ajax/desktop/listing/");

            var responseText = await response.TextAsync();

            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseText);
            JArray allData = (JArray)responseObject["offers"];
            JObject paginationObj = responseObject["pagination"];
            int totalCountPages = paginationObj.Value<int>("total_page_count");

            await PaginationAsync(page, totalCountPages, allData);

            await WriteJsonToFileAsync(responseObject);

            if (browser != null)
                await browser.CloseAsync();
        }

        // Записыва JSON в файл
        private Task WriteJsonToFileAsync(dynamic responseObject)
        {
            string json = JsonConvert.SerializeObject(responseObject);
            Random randomName = new Random();

            StreamWriter file = new StreamWriter($"{randomName.Next()}.txt");
            file.WriteLine(json);
            file.Close();

            return Task.CompletedTask;
        }

        // 
        private async Task CheckForCaptchaAsync(Page page)
        {
            var pageTitle = await page.GetTitleAsync();

            try
            {
                var currentUrl = page.Url;
                if (currentUrl.Contains("showcaptcha?") || pageTitle == "Ой!")
                {
                    await page.EvaluateFunctionAsync(@"() => {
                const button = document.querySelector('.CheckboxCaptcha-Button');
                if (button) {
                    button.style.display = 'block';
                    button.click();
                }
            }");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось решить каптчу, {e.Message}, пробую еще раз");
                await CheckForCaptchaAsync(page);
            }
        }

        private async Task PaginationAsync(Page page, int countPage, JArray allData)
        {
            try
            {
                for (int i = 2; i <= countPage; i++)
                {
                    await CheckForCaptchaAsync(page);

                    var nextPage = await page.QuerySelectorAsync(".Button.Button_color_white.Button_size_s.Button_type_link.Button_width_default.ListingPagination__next");
                    await page.HoverAsync(".Button.Button_color_white.Button_size_s.Button_type_link.Button_width_default.ListingPagination__next");

                    if (nextPage != null)
                        await nextPage.ClickAsync();

                    await CheckForCaptchaAsync(page);

                    var responseOfPage = await page.WaitForResponseAsync("https://auto.ru/-/ajax/desktop/listing/");

                    var responseTextOfPage = await responseOfPage.TextAsync();

                    var responseJsonOfPage = JsonConvert.DeserializeObject<dynamic>(responseTextOfPage);
                    // Получаю и преобразую в массив поле offers
                    JArray dataPage = (JArray)responseJsonOfPage["offers"];
                    Console.WriteLine(dataPage);

                    foreach (var offer in dataPage)
                    {
                        allData.Add(offer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошел сбой в методе PaginationAsync, {e.Message}, пробую еще раз");
                await PaginationAsync(page, countPage, allData);
                await page.WaitForNavigationAsync();
            }
        }


        private async Task<Browser> GetBrowserAsync()
        {
            var browserFetcher = new BrowserFetcher();
            if (await browserFetcher.CanDownloadAsync(BrowserFetcher.DefaultChromiumRevision))
            {
                await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            }

            var extra = new PuppeteerExtra();
            extra.Use(new StealthPlugin()).Use(new AnonymizeUaPlugin());


            browser = await extra.LaunchAsync(new LaunchOptions
            {
                Headless = false,
                Args = new[]
               {
                    "--disable-web-security",
                    "--disable-infobars",
                },
                //DefaultViewport = new ViewPortOptions
                //{
                //    Width = 1920,
                //    Height = 1080
                //},
                IgnoreHTTPSErrors = true,
            });
            _isBrowserOpen = browser.BrowserContexts().Length > 0;

            return browser;
        }

    }
}
