import { getAllRemnants } from "@/src/api/remnants";
import { useQuery } from "@tanstack/react-query";
import * as Location from "expo-location";
import React, { useEffect, useRef, useState } from "react";
import {
  ActivityIndicator,
  Platform,
  StyleSheet,
  Text,
  View,
} from "react-native";
import MapView, { Marker, Region } from "react-native-maps";
import { useTheme } from "../../theme";
import { darkMapStyle, lightMapStyle } from "../../theme/mapStyle";

const DEFAULT_REGION: Region = {
  latitude: 62.0,
  longitude: 15.0,
  latitudeDelta: 10,
  longitudeDelta: 10,
};

export default function IndexScreen() {
  const [errorMsg, setErrorMsg] = useState<string | null>(null);
  const mapRef = useRef<MapView>(null);
  const { dark } = useTheme();

  useEffect(() => {
    async function getCurrentLocation() {
      const { status } = await Location.requestForegroundPermissionsAsync();
      if (status !== "granted") {
        setErrorMsg("Permission to access location was denied");
        return;
      }

      const location = await Location.getCurrentPositionAsync({});
      mapRef.current?.animateToRegion({
        latitude: location.coords.latitude,
        longitude: location.coords.longitude,
        latitudeDelta: 3.5,
        longitudeDelta: 3.5,
      });
    }

    getCurrentLocation();
  }, []);

  const {
    data: remnants,
    isLoading,
    isError,
    error,
  } = useQuery({
    queryKey: ["remnants", "getAllRemnants"],
    queryFn: () => getAllRemnants(),
  });

  if (isLoading) {
    return (
      <View style={s.centered}>
        <ActivityIndicator size="large" />
      </View>
    );
  }
  if (isError && error) {
    return (
      <View style={s.centered}>
        <Text>{error.message}</Text>
      </View>
    );
  }

  if (Platform.OS === "web") {
    return (
      <View style={s.map}>
        <Text>Maps are not available on web</Text>
      </View>
    );
  }

  return (
    <MapView
      ref={mapRef}
      initialRegion={DEFAULT_REGION}
      userInterfaceStyle={dark ? "dark" : "light"}
      customMapStyle={dark ? darkMapStyle : lightMapStyle}
      style={s.map}
    >
      {remnants?.map((r) => (
        <Marker
          key={r.identifier}
          coordinate={{ latitude: r.latitude, longitude: r.longitude }}
          title={r.identifier}
          description={r.description}
        />
      ))}
    </MapView>
  );
}

const s = StyleSheet.create({
  map: {
    flex: 1,
  },
  centered: {
    justifyContent: "center",
    alignItems: "center",
    flex: 1,
  },
});
