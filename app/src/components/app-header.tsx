import { useTheme } from "@/src/theme";
import Ionicons from "@expo/vector-icons/Ionicons";
import { DrawerActions } from "@react-navigation/native";
import { useNavigation } from "expo-router";
import { Pressable, StyleSheet, Text, View } from "react-native";
import { useSafeAreaInsets } from "react-native-safe-area-context";

export default function AppHeader() {
  const insets = useSafeAreaInsets();
  const { colors } = useTheme();
  const navigation = useNavigation();

  return (
    <View
      style={[
        s.container,
        { paddingTop: insets.top, backgroundColor: colors.primary },
      ]}
    >
      <View style={[s.logo, { backgroundColor: colors.tertiary }]}>
        <Text style={s.logoRune}>ᚱ</Text>
      </View>
      <Text style={s.title}>foᚱnspår</Text>
      <Pressable
        onPress={() => navigation.dispatch(DrawerActions.toggleDrawer())}
        style={s.menu}
        hitSlop={8}
      >
        <Ionicons name="menu-outline" size={28} color="#ffffff" />
      </Pressable>
    </View>
  );
}

const s = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "center",
    paddingHorizontal: 16,
    paddingBottom: 12,
    gap: 10,
  },
  logo: {
    width: 36,
    height: 36,
    borderRadius: 8,
    alignItems: "center",
    justifyContent: "center",
  },
  logoRune: {
    color: "#ffffff",
    fontSize: 20,
    fontWeight: "bold",
  },
  title: {
    flex: 1,
    color: "#ffffff",
    fontSize: 20,
    fontWeight: "700",
    letterSpacing: 0.5,
  },
  menu: {
    padding: 4,
  },
});
