import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { ConfigService } from './config.service';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '../helpers/httpClient';

@Injectable()
export class BalanceService {
  constructor(private http: HttpClient, private configService: ConfigService) {
  }

  private balanceApiUri = `${this.configService.apiPrefix}/balances`;

  getHistory(userId: string): Observable<any> {
    return this.http.getWithQuery(`${this.balanceApiUri}/histories`, `userId=${userId}`)
      .map(this.mapBalance)
      .catch(this.handleError);
  }


  putBalance(userId: string, amount: string): Observable<any> {
    return this.http.put(`${this.balanceApiUri}`, { userId: userId, amount: amount })
      .map(this.mapBalance)
      .catch(this.handleError);
  }

  mapBalance = (res: Response): number => {
    let updatedBalance = res.json();
    return updatedBalance;
  }

  private handleError(error: any) {
    if (error._body) {
      var errorObj = JSON.parse(error._body);
      if (errorObj.modelState) {
        return Observable.throw(errorObj.modelState[Object.keys(errorObj.modelState)[0]]);
      }
    }
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    let errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg); // log to console instead
    return Observable.throw(errMsg);
  }
}