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
  return z
    .object({
      nickName: z
        .string()
        .min(3, t("auth.nameTooShort"))
        .max(20, t("auth.nameTooLong")),
      email: z.email(t("auth.emailInvalid")),
      password: z
        .string()
        .min(1, t("auth.passwordRequired"))
        .min(8, t("auth.passwordTooShort")),
      confirmPassword: z
        .string(t("auth.repeatPassword"))
        .min(8, t("auth.passwordTooShort")),
    })
    .superRefine(({ confirmPassword, password }, ctx) => {
      if (confirmPassword !== password) {
        ctx.addIssue({
          code: "custom",
          message: t("auth.passwordsDontMatch"),
          path: ["confirmPassword"],
        });
      }
    });
}

export default function RegisterScreen() {
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
    defaultValues: { email: "", password: "", nickName: "" },
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
          <View style={s.registerMsg}>
            <Text style={{ color: colors.secondary, fontSize: 18 }}>
              {t("auth.registerMsg")}
            </Text>
          </View>
          <Text style={[s.inputTitle, { color: colors.text }]}>
            {t("auth.nickName")}
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
                placeholder={t("auth.nickName")}
                placeholderTextColor={colors.text}
                keyboardType="default"
              />
            )}
            name="nickName"
          />
          <View>
            {errors.nickName && (
              <Text style={[s.errorMsg, { color: colors.error }]}>
                {errors.nickName.message}
              </Text>
            )}
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
          <Text style={[s.inputTitle, { color: colors.text }]}>
            {t("auth.repeatPassword")}
          </Text>
          <Controller
            control={control}
            name="confirmPassword"
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
            {errors.confirmPassword && (
              <Text style={[s.errorMsg, { color: colors.error }]}>
                {errors.confirmPassword.message}
              </Text>
            )}
          </View>

          <View style={{ paddingTop: 10, paddingBottom: 10 }}>
            <Pressable
              onPress={handleSubmit(onSubmit)}
              style={[
                s.button,
                {
                  backgroundColor: isSubmitting
                    ? colors.neutral
                    : colors.primary,
                },
              ]}
              disabled={isSubmitting}
              accessibilityLabel={t("auth.accessibilityLabel")}
            >
              <Text style={s.buttonText}>
                {isSubmitting ? t("auth.registering") : t("auth.register")}
              </Text>
            </Pressable>
          </View>
          <View style={s.createAccount}>
            <Pressable onPress={() => router.push("/(tabs)/(auth)/login")}>
              <Text style={[s.createAccountText, { color: colors.text }]}>
                {t("auth.alreadyMember")}
              </Text>
            </Pressable>
          </View>
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
    gap: 10,
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
  registerMsg: {
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
