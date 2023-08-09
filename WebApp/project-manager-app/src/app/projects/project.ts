import { Manager } from '../shared/manager';
import { Task } from './task';

export interface Project {
  id: number;
  name: string;
  budget: number;
  managerAssignedTo: Manager;
  tasks: Task[];
}

export interface NewProject {
  name: string;
  budget: number;
  managerId: number;
}
