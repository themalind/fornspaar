import DrawerContent from "@/src/components/drawer-content";
import "@/src/i18n";
import { ThemeProvider, useTheme } from "@/src/theme";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { Drawer } from "expo-router/drawer";
import { StatusBar } from "expo-status-bar";

const queryClient = new QueryClient();

function RootLayoutInner() {
  const { colors, dark } = useTheme();

  return (
    <>
      <StatusBar style={dark ? "light" : "dark"} />
      <Drawer
        drawerContent={(props) => <DrawerContent {...props} />}
        screenOptions={{
          headerShown: false,
          drawerStyle: { backgroundColor: colors.surface },
        }}
      >
        <Drawer.Screen name="(tabs)" />
      </Drawer>
    </>
  );
}

export default function RootLayout() {
  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider>
        <RootLayoutInner />
      </ThemeProvider>
    </QueryClientProvider>
  );
}
