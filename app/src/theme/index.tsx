import AsyncStorage from "@react-native-async-storage/async-storage";
import React, {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useState,
} from "react";
import { useColorScheme } from "react-native";
import { darkColors, lightColors, type ColorPalette } from "./colors";

export type { ColorPalette };

const STORAGE_KEY = "theme_override";

type Theme = {
  colors: ColorPalette;
  dark: boolean;
  toggleTheme: () => void;
};

const ThemeContext = createContext<Theme>({
  colors: lightColors,
  dark: false,
  toggleTheme: () => {},
});

export function useTheme() {
  return useContext(ThemeContext);
}

export function ThemeProvider({
  children,
}: {
  children: React.ReactNode;
}): React.JSX.Element {
  const systemScheme = useColorScheme();
  const [override, setOverride] = useState<"light" | "dark" | null>(null);
  const [loaded, setLoaded] = useState(false);

  useEffect(() => {
    AsyncStorage.getItem(STORAGE_KEY).then((value) => {
      if (value === "light" || value === "dark") {
        setOverride(value);
      }
      setLoaded(true);
    });
  }, []);

  const toggleTheme = useCallback(async () => {
    const currentDark =
      override !== null ? override === "dark" : systemScheme === "dark";
    const next = currentDark ? "light" : "dark";
    setOverride(next);
    await AsyncStorage.setItem(STORAGE_KEY, next);
  }, [override, systemScheme]);

  const dark =
    override !== null ? override === "dark" : systemScheme === "dark";

  if (!loaded) return <>{children}</>;

  return (
    <ThemeContext.Provider
      value={{ colors: dark ? darkColors : lightColors, dark, toggleTheme }}
    >
      {children}
    </ThemeContext.Provider>
  );
}
