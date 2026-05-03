import { useLanguage } from "@/src/i18n/useLanguage";
import { useTheme } from "@/src/theme";
import AntDesign from "@expo/vector-icons/AntDesign";
import { DrawerContentComponentProps } from "@react-navigation/drawer";
import React from "react";
import { useTranslation } from "react-i18next";
import { Pressable, StyleSheet, Text, View } from "react-native";
import { useSafeAreaInsets } from "react-native-safe-area-context";

export default function DrawerContent(props: DrawerContentComponentProps) {
  const { colors, dark, toggleTheme } = useTheme();
  const insets = useSafeAreaInsets();
  const { t } = useTranslation();
  const { language, toggleLanguage } = useLanguage();

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
      <Pressable onPress={toggleLanguage}>
        <View style={[styles.footer, { borderTopColor: colors.border }]}>
          <Text style={[styles.footerLabel, { color: colors.text }]}>
            {t("drawer.language")}
          </Text>
          <Text style={[styles.footerLabel, { color: colors.primary }]}>
            {language.toUpperCase()}
          </Text>
        </View>
      </Pressable>

      <Pressable onPress={toggleTheme}>
        <View style={[styles.footer, { borderTopColor: colors.border }]}>
          <Text style={[styles.footerLabel, { color: colors.text }]}>
            {dark ? t("drawer.darkMode") : t("drawer.lightMode")}
          </Text>

          {dark ? (
            <AntDesign name="moon" size={24} color={colors.primary} />
          ) : (
            <AntDesign name="sun" size={24} color={colors.primary} />
          )}
        </View>
      </Pressable>
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
  footer: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
    padding: 20,
    borderTopWidth: StyleSheet.hairlineWidth,
  },
  footerLabel: {
    fontSize: 14,
  },
});
