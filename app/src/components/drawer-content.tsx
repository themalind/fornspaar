import { useTheme } from "@/src/theme";
import { DrawerContentComponentProps } from "@react-navigation/drawer";
import { useTranslation } from "react-i18next";
import { StyleSheet, Text, View } from "react-native";
import { useSafeAreaInsets } from "react-native-safe-area-context";

export default function DrawerContent(props: DrawerContentComponentProps) {
  const { colors } = useTheme();
  const insets = useSafeAreaInsets();
  const { t } = useTranslation();

  return (
    <View
      style={[
        styles.container,
        {
          paddingTop: insets.top,
          paddingBottom: insets.bottom,
          backgroundColor: colors.surface,
        },
      ]}
    >
      <View style={[styles.header, { borderBottomColor: colors.border }]}>
        <View style={[styles.logo, { backgroundColor: colors.tertiary }]}>
          <Text style={styles.logoRune}>ᚱ</Text>
        </View>
        <Text style={[styles.appName, { color: colors.text }]}>foᚱnspår</Text>
      </View>

      <View style={styles.content}>
        <Text style={[styles.placeholder, { color: colors.textSecondary }]}>
          {t("drawer.menuPlaceholder")}
        </Text>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  header: {
    flexDirection: "row",
    alignItems: "center",
    gap: 12,
    padding: 20,
    borderBottomWidth: StyleSheet.hairlineWidth,
  },
  logo: {
    width: 40,
    height: 40,
    borderRadius: 10,
    alignItems: "center",
    justifyContent: "center",
  },
  logoRune: {
    color: "#ffffff",
    fontSize: 22,
    fontWeight: "bold",
  },
  appName: {
    fontSize: 20,
    fontWeight: "700",
    letterSpacing: 0.5,
  },
  content: {
    flex: 1,
    padding: 20,
  },
  placeholder: {
    fontSize: 14,
  },
});
