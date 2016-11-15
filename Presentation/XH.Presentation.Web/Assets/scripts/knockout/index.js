var TranslationManager = (function () {
    var languages = [
        { code: "en", name: "English" },
        { code: "nl", name: "Dutch" },
        { code: "fr", name: "French" },
        { code: "de", name: "German" },
        { code: "es", name: "Spanish" },
        { code: "pt", name: "Portuguese" }
    ];

    var codeKey = "LanguageCode",
        nameKey = "LanguageName",
        valueKey = "Value";

    var defaultLanguageCode = "en";

    function sortTranslationCollectionByLanguages(translationCollection) {
        var orderedCodes = languages.map(function (item) { return item.code });
        translationCollection.sort(function (a, b) {
            var indexA = orderedCodes.indexOf(a[codeKey]),
                indexB = orderedCodes.indexOf(b[codeKey]);

            return indexA - indexB;
        });
    }

    function TranslationManager(translationCollection) {
        this.init(translationCollection);
    }

    TranslationManager.prototype.init = function (translationCollection) {
        this.languageCodeMapping = {};
        this.remainTranslations = [];

        for (var i = 0, len = languages.length; i < len; i++) {
            this.languageCodeMapping[languages[i].code] = languages[i].name;
        }

        this.translationCollection = translationCollection || []; // get from api;
        sortTranslationCollectionByLanguages(this.translationCollection);

        var translatedLanguageCodes = this.translationCollection.map(function (item) { return item[codeKey] });

        // fill remain translations;
        this.remainTranslations = Enumerable.from(languages).where(function (item) {
            return translatedLanguageCodes.indexOf(item.code) < 0;
        }).toArray();

        for (var i = 0, len = translatedLanguageCodes; i < len; i++) {
            var code = translatedLanguageCodes[i],
                languageName = this.languageCodeMapping[code];

            this.translationCollection[i][nameKey] = languageName;
        }

        // check if have en translation
        if (translatedLanguageCodes.indexOf(defaultLanguageCode) < 0) {
            this.addTranslation(defaultLanguageCode);
        }
    }

    TranslationManager.prototype.getLanguageNameByCode = function (code) {
        return this.languageCodeMapping[code];
    }

    TranslationManager.prototype.addTranslation = function (languageCode, value) {
        var index = Enumerable.from(this.remainTranslations).indexOf(function (item) { return item.code == languageCode });
        if (index > -1) {
            // valid code;
            var translation = {};
            translation[codeKey] = languageCode;
            translation[nameKey] = this.languageCodeMapping[languageCode];
            translation[valueKey] = value;

            this.translationCollection.push(translation);
            this.remainTranslations.splice(index, 1);
        }
    };

    TranslationManager.prototype.removeTranslation = function (languageCode) {
        if (languageCode == defaultLanguageCode) {
            return;
        }

        var index = Enumerable.from(this.translationCollection).indexOf(function (item) { return item[codeKey] == languageCode });
        if (index > -1) {
            this.translationCollection.splice(index, 1);
            var language = Enumerable.from(languages).firstOrDefault(function (item) { return item.code === languageCode });

            if (language) {
                this.remainTranslations.push(language);
            }
        }
    };

    return TranslationManager;
})();

appConfig.app
.controller("knockoutController", ["$scope", function ($scope) {
    var tm = $scope.tm = new TranslationManager();

    $scope.submit = function () {
        console.log(tm.translationCollection);
    }

    $scope.alertMe = function (code) {
        alert(code);
    }

    $scope.translations = [];
}]);