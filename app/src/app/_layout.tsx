import "@/src/i18n";
import { Drawer } from "expo-router/drawer";
import { ThemeProvider, useTheme } from "@/src/theme";
import DrawerContent from "@/src/components/drawer-content";

function RootLayoutInner() {
  const { colors } = useTheme();
  return (
    <Drawer
      drawerContent={(props) => <DrawerContent {...props} />}
      screenOptions={{
        headerShown: false,
        drawerStyle: { backgroundColor: colors.surface },
      }}
    >
      <Drawer.Screen name="(tabs)" />
    </Drawer>
  );
}

export default function RootLayout() {
  return (
    <ThemeProvider>
      <RootLayoutInner />
    </ThemeProvider>
  );
}
