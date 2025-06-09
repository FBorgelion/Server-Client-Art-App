import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArtisanService {

  constructor(private http: HttpClient) { }

  getArtisan(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Artisan/id`);
  }

  updateDescription(description: string): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/api/Artisan/description`, { profileDescription: description });
  }

}
