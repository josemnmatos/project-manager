import { Developer } from "./developer";
import { Project } from "./project";

export interface Task {
  id: number;
  name: string;
  description: string;
  state: number;
  deadline: Date;
  developerAssignedTo: Developer;
  projectAssociatedTo: Project;
  developerId: number;
}
