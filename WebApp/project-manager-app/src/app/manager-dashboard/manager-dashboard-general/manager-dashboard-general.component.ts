import { Component } from '@angular/core';
import { Input } from '@angular/core';
import { Manager } from 'src/app/shared/manager';

@Component({
  selector: 'app-manager-dashboard-general',
  templateUrl: './manager-dashboard-general.component.html',
  styleUrls: ['./manager-dashboard-general.component.css']
})
export class ManagerDashboardGeneralComponent {

  @Input() manager!: Manager;

}
