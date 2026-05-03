import { getLocales } from "expo-localization";
import i18n, { use as i18nUse } from "i18next";
import { initReactI18next } from "react-i18next";
import en from "./locales/en";
import sv from "./locales/sv";

const deviceLanguage = getLocales()[0]?.languageCode ?? "sv";

i18nUse(initReactI18next).init({
  resources: {
    sv: { translation: sv },
    en: { translation: en },
  },
  lng: deviceLanguage,
  fallbackLng: "sv",
  interpolation: { escapeValue: false },
});

export default i18n;
