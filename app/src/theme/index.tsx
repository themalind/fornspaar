import React, { createContext, useContext } from "react";
import { useColorScheme } from "react-native";
import { darkColors, lightColors, type ColorPalette } from "./colors";

export type { ColorPalette };

type Theme = {
  colors: ColorPalette;
  dark: boolean;
};

const ThemeContext = createContext<Theme>({ colors: lightColors, dark: false });

export function useTheme() {
  return useContext(ThemeContext);
}

export function ThemeProvider({
  children,
}: {
  children: React.ReactNode;
}): React.JSX.Element {
  const scheme = useColorScheme();
  const dark = scheme === "dark";
  return (
    <ThemeContext.Provider
      value={{ colors: dark ? darkColors : lightColors, dark }}
    >
      {children}
    </ThemeContext.Provider>
  );
}
