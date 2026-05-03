export type ColorPalette = {
  background: string;
  surface: string;
  primary: string;
  secondary: string;
  tertiary: string;
  neutral: string;
  text: string;
  textSecondary: string;
  border: string;
  tabBar: string;
  tabBarActive: string;
  tabBarInactive: string;
  error: string;
};

export const lightColors: ColorPalette = {
  background: "#ffffff",
  surface: "#f4f7f8",
  primary: "#0e7490",
  secondary: "#5f7b87",
  tertiary: "#965e1c",
  neutral: "#74787a",
  text: "#1a1a1a",
  textSecondary: "#74787a",
  border: "#dde3e5",
  tabBar: "#ffffff",
  tabBarActive: "#0e7490",
  tabBarInactive: "#74787a",
  error: "#b94040",
};

export const darkColors: ColorPalette = {
  background: "#0d1a1e",
  surface: "#162226",
  primary: "#22a8c8",
  secondary: "#7a9baa",
  tertiary: "#c07b30",
  neutral: "#8c9092",
  text: "#f0f4f5",
  textSecondary: "#8c9092",
  border: "#2a3a40",
  tabBar: "#0d1a1e",
  tabBarActive: "#22a8c8",
  tabBarInactive: "#8c9092",
  error: "#e05c5c",
};
