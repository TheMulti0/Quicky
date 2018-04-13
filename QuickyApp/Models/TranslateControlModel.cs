using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTranslate.Enums;
using EasyTranslate.Translators;
using EasyTranslate.Words;

namespace QuickyApp.Models
{
    internal class TranslateControlModel
    {
        private readonly ITranslator _translator;

        public TranslateControlModel() 
            => _translator = new GoogleTranslateClassicTranslator();

        public TranslateWord Translate(TranslateWord word, TranslateLanguages targetLanguage)
            => _translator.Translate(word, targetLanguage);

        public TranslateWord Detect(TranslateWord word)
            => _translator.Detect(word);
    }
}
