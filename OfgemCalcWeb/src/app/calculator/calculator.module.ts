import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";

import { CalculatorComponent} from './calculator.component';


@NgModule({
  declarations: [
    CalculatorComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class CalculatorModule { path: 'calculator'; component: CalculatorComponent }
