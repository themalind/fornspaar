import { Link } from "expo-router";
import { Text, View } from "react-native";

export default function ProfileScreen() {
  return (
    <View
      style={{
        padding: 30,
        gap: 20,
      }}
    >
      <Link
        style={{
          fontSize: 20,
          fontWeight: 700,
          textDecorationLine: "underline",
        }}
        href="/(tabs)/(auth)/login"
      >
        login
      </Link>
      <Link
        style={{
          fontSize: 20,
          fontWeight: 700,
          textDecorationLine: "underline",
        }}
        href="/(tabs)/(auth)/register"
      >
        registrera
      </Link>
      <Text>hejhej från profil</Text>
    </View>
  );
}
