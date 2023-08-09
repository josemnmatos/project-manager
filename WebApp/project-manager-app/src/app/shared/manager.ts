import { Project } from './project';

export interface Manager {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  projects?: Project[];
}
