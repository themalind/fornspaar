import PasswordInputField from "@/src/components/password-input-field";
import { useTheme } from "@/src/theme";
import { zodResolver } from "@hookform/resolvers/zod";
import { router } from "expo-router";
import { Controller, SubmitHandler, useForm } from "react-hook-form";
import { useTranslation } from "react-i18next";
import {
  Alert,
  KeyboardAvoidingView,
  Platform,
  Pressable,
  ScrollView,
  StyleSheet,
  Text,
  TextInput,
  View,
} from "react-native";
import { z } from "zod";

function createLoginSchema(t: (key: string) => string) {
  return z.object({
    email: z.email(t("auth.emailInvalid")),
    password: z
      .string()
      .min(1, t("auth.passwordRequired"))
      .min(8, t("auth.passwordTooShort")),
  });
}

export default function LoginScreen() {
  const { colors } = useTheme();
  const { t } = useTranslation();

  const loginSchema = createLoginSchema(t);
  type FormFields = z.infer<typeof loginSchema>;

  const {
    control,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<FormFields>({
    resolver: zodResolver(loginSchema),
    defaultValues: { email: "", password: "" },
  });

  const onSubmit: SubmitHandler<FormFields> = async (data) => {
    Alert.alert("Inloggad");
  };

  return (
    <KeyboardAvoidingView
      style={[s.screen, { backgroundColor: colors.background }]}
      behavior={Platform.OS === "ios" ? "padding" : "height"}
    >
      <ScrollView
        contentContainerStyle={s.scrollContent}
        keyboardShouldPersistTaps="handled"
        automaticallyAdjustKeyboardInsets
      >
        <View style={[s.card, { backgroundColor: colors.surface }]}>
          <View style={s.logoContainer}>
            <View style={[s.logo, { backgroundColor: colors.tertiary }]}>
              <Text style={s.logoRune}>ᚱ</Text>
            </View>
            <Text style={s.title}>foᚱnspår</Text>
          </View>
          <View style={s.welcomeMsg}>
            <Text style={{ color: colors.secondary, fontSize: 18 }}>
              {t("auth.welcomeBackMsg")}
            </Text>
          </View>
          <Text style={[s.inputTitle, { color: colors.text }]}>
            {t("auth.email")}
          </Text>
          <Controller
            control={control}
            render={({ field: { onChange, onBlur, value } }) => (
              <TextInput
                onBlur={onBlur}
                onChangeText={onChange}
                style={[
                  s.textInput,
                  { color: colors.text, backgroundColor: colors.neutral },
                ]}
                value={value}
                placeholder={t("auth.email")}
                placeholderTextColor={colors.text}
                keyboardType="email-address"
              />
            )}
            name="email"
          />
          <View>
            {errors.email && (
              <Text style={[s.errorMsg, { color: colors.error }]}>
                {errors.email.message}
              </Text>
            )}
          </View>
          <Text style={[s.inputTitle, { color: colors.text }]}>
            {t("auth.password")}
          </Text>
          <Controller
            control={control}
            name="password"
            render={({ field: { onChange, onBlur, value } }) => (
              <PasswordInputField
                value={value}
                onChangeText={onChange}
                onBlur={onBlur}
                placeholder={t("auth.password")}
                error={!!errors.password}
                onSubmitEditing={handleSubmit(onSubmit)}
              />
            )}
          />
          <View>
            {errors.password && (
              <Text style={[s.errorMsg, { color: colors.error }]}>
                {errors.password.message}
              </Text>
            )}
          </View>
          <View style={s.createAccount}>
            <Pressable onPress={() => router.push("/(tabs)/(auth)/register")}>
              <Text style={[s.createAccountText, { color: colors.text }]}>
                {t("auth.notRegistered")}
              </Text>
            </Pressable>
          </View>
          <Pressable
            onPress={handleSubmit(onSubmit)}
            style={[
              s.button,
              {
                backgroundColor: isSubmitting ? colors.neutral : colors.primary,
              },
            ]}
            disabled={isSubmitting}
            accessibilityLabel={t("auth.accessibilityLabel")}
          >
            <Text style={s.buttonText}>
              {isSubmitting ? t("auth.loggingIn") : t("auth.login")}
            </Text>
          </Pressable>
        </View>
      </ScrollView>
    </KeyboardAvoidingView>
  );
}

const s = StyleSheet.create({
  screen: {
    flex: 1,
  },
  scrollContent: {
    flexGrow: 1,
    justifyContent: "center",
    padding: 16,
  },
  card: {
    alignSelf: "center",
    width: "90%",
    padding: 24,
    gap: 15,
    borderRadius: 12,
  },
  textInput: {
    borderRadius: 10,
    padding: 14,
  },
  button: {
    borderRadius: 10,
    padding: 10,
    alignItems: "center",
  },
  buttonText: {
    color: "#ffffff",
    fontWeight: "600",
    fontSize: 16,
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
  inputTitle: {
    fontWeight: 500,
    fontSize: 15,
  },
  welcomeMsg: {
    alignItems: "center",
  },
  logoContainer: {
    flexDirection: "row",
    alignItems: "center",
    gap: 15,
    paddingBottom: 10,
  },
  errorMsg: {
    fontWeight: 600,
    fontSize: 13,
  },
  createAccount: {
    alignItems: "center",
  },
  createAccountText: {
    textDecorationLine: "underline",
    fontWeight: 600,
  },
});
