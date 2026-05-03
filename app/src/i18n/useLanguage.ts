import AsyncStorage from "@react-native-async-storage/async-storage";
import { useCallback, useEffect, useState } from "react";
import { useTranslation } from "react-i18next";

const STORAGE_KEY = "language_override";
type Language = "sv" | "en";

export function useLanguage() {
  const { i18n } = useTranslation();
  const [language, setLanguage] = useState<Language>(
    (i18n.language as Language) ?? "sv"
  );

  useEffect(() => {
    AsyncStorage.getItem(STORAGE_KEY).then((saved) => {
      if (saved === "sv" || saved === "en") {
        setLanguage(saved);
        i18n.changeLanguage(saved);
      }
    });
  }, []);

  const toggleLanguage = useCallback(async () => {
    const next: Language = language === "sv" ? "en" : "sv";
    setLanguage(next);
    await i18n.changeLanguage(next);
    await AsyncStorage.setItem(STORAGE_KEY, next);
  }, [language, i18n]);

  return { language, toggleLanguage };
}
