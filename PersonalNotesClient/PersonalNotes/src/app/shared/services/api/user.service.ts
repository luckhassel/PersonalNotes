import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { endpoints } from 'src/app/data/constants/backend-constants';
import { UserAuthenticateResponse } from 'src/app/data/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private readonly http: HttpClient) { }

  createUser(name: string, password: string): Observable<any>{
    return this.http.post<any>(endpoints.baseApiUrl + endpoints.user.createUser, {
      UserName: name,
      Password: password
    });
  }

  authenticate(name: string, password: string): Observable<UserAuthenticateResponse>{
    return this.http.post<any>(endpoints.baseApiUrl + endpoints.user.authenticate, {
      UserName: name,
      Password: password
    });
  }
}
