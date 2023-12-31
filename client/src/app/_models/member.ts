import { Photo } from "./photo";

export interface Member {
  id: number;
  userName: string;
  photoUrl: string;
  age: number;
  knownAs: string;
  created: string;
  lastActive: string;
  gender: string;
  lookingFor: string;
  interests: string;
  introduction: string;
  city: string;
  country: string;
  photos: Photo[];
}

