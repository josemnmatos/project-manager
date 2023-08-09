import { Developer } from "./developer";

export interface Task {
  id: number;
  name: string;
  description: string;
  state: number;
  deadline: Date;
  developerAssignedTo: Developer;
}
