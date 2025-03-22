import { Photo } from './photo';

export interface Member {
  id: number;
  userName: string;
  age: number;
  birdthDate: Date;
  knownAs: string;
  created: Date;
  lastActive: string;
  gender: string;
  introduction: string;
  interests: string;
  lookingFor: string;
  city: string;
  country: string;
  photos: Photo[];
  photoUrl: string;
}
