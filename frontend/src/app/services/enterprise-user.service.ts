import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { EnterpriseUserResponse } from '../models/enterprise-user-response.model';

@Injectable({
  providedIn: 'root'
})
export class EnterpriseUserService {

  private apiUrl = 'http://localhost:5115/api/EnterpriseUser';

  constructor(private http: HttpClient, private router: Router) { }

  getEnterpriseUsers(): Observable<EnterpriseUserResponse[]> {
    return this.http.get<EnterpriseUserResponse[]>(`${this.apiUrl}/GetEnterpriseUsers`);
  }

  getEnterpriseUserById(id: number): Observable<EnterpriseUserResponse> {
    return this.http.get<EnterpriseUserResponse>(`${this.apiUrl}/GetEnterpriseUserById/${id}`);
  }
}
