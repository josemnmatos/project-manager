import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'daysAgo',
})
export class DaysAgoPipe implements PipeTransform {
   transform(deadline: any): any {
      const currentDate = new Date();
      const deadlineDate = new Date(deadline);
      const timeDiff = deadlineDate.getTime() - currentDate.getTime();
      const daysLeft = Math.ceil(timeDiff / (1000 * 60 * 60 * 24));
  
      if (daysLeft < 0) {
        return 'Expired';
      } else {
        return daysLeft + ' days';
      }
    }
}
