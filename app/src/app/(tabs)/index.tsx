import { Platform, StyleSheet, Text, View } from "react-native";
import MapView from "react-native-maps";

export default function IndexScreen() {
  if (Platform.OS === "web") {
    return (
      <View style={s.map}>
        <Text>Maps are not available on web</Text>
      </View>
    );
  }

  return <MapView style={s.map} />;
}

const s = StyleSheet.create({
  map: {
    flex: 1,
  },
});
