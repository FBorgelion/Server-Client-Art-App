import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArtisanService {

  constructor(private http: HttpClient) { }

  getArtisans(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Artisan`);
  }

  getArtisan(): Observable<any> {
    return this.http.get(`https://localhost:7041/api/Artisan/id`);
  }

  updateDescription(description: string): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/api/Artisan/description`, { profileDescription: description });
  }

  deleteArtisan(id: number): Observable<any> {
     return this.http.delete(`https://localhost:7041/api/Artisan/${id}`);
  }

}
