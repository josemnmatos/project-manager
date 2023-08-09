import { Task } from '../projects/task';

export interface Developer {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  tasks?: Task[];
}
