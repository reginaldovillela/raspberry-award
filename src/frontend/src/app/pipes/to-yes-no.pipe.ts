import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toYesNo',
  standalone: false,
})
export class ToYesNoPipe implements PipeTransform {
  transform(value: unknown, ...args: unknown[]): unknown {
    return value == true ? 'Yes' : 'No';
  }
}
