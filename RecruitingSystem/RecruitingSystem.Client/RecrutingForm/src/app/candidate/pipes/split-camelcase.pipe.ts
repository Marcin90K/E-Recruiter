import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'splitCamelcase'
})
export class SplitCamelcasePipe implements PipeTransform {

  transform(value: string, args?: any): any {
    const valueCapitalized = value.charAt(0).toUpperCase() + value.slice(1);

    return valueCapitalized.replace(/([a-z])([A-Z])/g, '$1 $2');
  }

}
