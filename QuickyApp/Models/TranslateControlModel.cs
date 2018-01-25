using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTranslate.Enums;
using EasyTranslate.Factories;
using EasyTranslate.Implementations;
using EasyTranslate.Translators;
using EasyTranslate.Words;

namespace QuickyApp.Models
{
    internal class TranslateControlModel
    {
        private readonly IRemoteWebDriver _driver;
        private readonly ITranslator _translator;

        public TranslateControlModel()
        {
            const DriverTypes type = DriverTypes.PhantomJSDriver;
            string path = Environment.CurrentDirectory;

            var factory = new RemoteWebDriverFactory();
            _driver = factory.Create(type, path);

            _translator = new SeleniumClassicGoogleTranslator();
        }

        public TranslateWord Translate(TranslateWord word, TranslateLanguages targetLanguage)
            => _translator.Translate(word, targetLanguage, _driver);

        public TranslateWord Detect(TranslateWord word)
            => _translator.Detect(word, _driver);
    }
}
