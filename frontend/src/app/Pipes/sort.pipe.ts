import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'sort'
})
export class SortPipe implements PipeTransform {

  firstField='';
  secondField='';
  transform(value: Array<string>, args: any[]): any {
    const sortField = args[0];
    const sortDirection = args[1];
    let multiplier = 1;

    if (sortDirection === 'desc') {
      multiplier = -1;
    }

    value.sort((a: any, b: any) => {
      if(sortField==="City")
      {
         this.firstField=a[sortField];
         this.secondField=b[sortField];
        if (this.firstField.toUpperCase() < this.secondField.toUpperCase()) {
          return -1 * multiplier;
        } else if (this.firstField.toUpperCase() > this.secondField.toUpperCase()) {
          return 1 * multiplier;
        } else {
          return 0;
        }
      }
      else
      {
        if (a[sortField] < b[sortField]) {
          return -1 * multiplier;
        } else if (a[sortField] > b[sortField]) {
          return 1 * multiplier;
        } else {
          return 0;
        }
      }

    }
    );

    return value;
  }
}
