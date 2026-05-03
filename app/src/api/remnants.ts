import { RemnantResponse } from "../data/types";
import { BASE_URL } from "./api-config";

export async function getAllRemnants(): Promise<RemnantResponse[]> {
  try {
    const response = await fetch(`${BASE_URL}/remnant/all`);

    if (!response.ok) {
      throw new Error(`HTTP error ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.log("getAllRemnants: ", error);
    throw error;
  }
}
