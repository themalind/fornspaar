import { useTheme } from "@/src/theme";
import Ionicons from "@expo/vector-icons/Ionicons";
import { useState } from "react";
import {
  Pressable,
  ReturnKeyTypeOptions,
  StyleSheet,
  TextInput,
  View,
} from "react-native";

interface Props {
  value: string;
  onChangeText: (value: string) => void;
  onBlur?: () => void;
  placeholder?: string;
  error?: boolean;
  onSubmitEditing?: () => void;
  returnKeyType?: ReturnKeyTypeOptions;
}

export default function PasswordInputField({
  value,
  onChangeText,
  onBlur,
  placeholder,
  error,
  onSubmitEditing,
  returnKeyType = "done",
}: Props) {
  const { colors } = useTheme();
  const [showPassword, setShowPassword] = useState(false);

  return (
    <View
      style={[
        s.container,
        { backgroundColor: colors.neutral },
        error && { borderWidth: 1, borderColor: colors.tertiary },
      ]}
    >
      <TextInput
        style={[s.input, { color: colors.text }]}
        value={value}
        onChangeText={onChangeText}
        onBlur={onBlur}
        placeholder={placeholder}
        placeholderTextColor={colors.text}
        secureTextEntry={!showPassword}
        autoCapitalize="none"
        onSubmitEditing={onSubmitEditing}
        returnKeyType={returnKeyType}
      />
      <Pressable
        onPress={() => setShowPassword((v) => !v)}
        hitSlop={8}
        style={s.toggle}
      >
        <Ionicons
          name={showPassword ? "eye-off-outline" : "eye-outline"}
          size={20}
          color={colors.text}
        />
      </Pressable>
    </View>
  );
}

const s = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "center",
    borderRadius: 10,
    paddingHorizontal: 14,
  },
  input: {
    flex: 1,
    paddingVertical: 14,
  },
  toggle: {
    paddingLeft: 8,
  },
});
