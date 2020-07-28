import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})

export class CalculatorService {

    private url ='https://localhost:5001/api/calculator/';
    
    constructor(private http: HttpClient) {  }

    calculate(operand1: number, operand2: number, operation: string): Observable<number> {
        console.log('calculate');
        let httpParams = new HttpParams()
            .set('firstNumber', operand1.toString())
            .set('secondNumber', operand2.toString());
        var result;
        console.log('calling ' + this.url + operation.toLowerCase());
        return this.http.get<number>(this.url + operation.toLowerCase(), { params: httpParams });
        
    };
}