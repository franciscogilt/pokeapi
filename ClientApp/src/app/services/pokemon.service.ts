import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  
  constructor(private http: HttpClient) { }
  
  getPokemon(){
    return this.http.get('/api/pokemon');
  }

  getPokemonByName(name: string) {
    return this.http.get(`/api/pokemon/${name}`);
  }

  downloadPokemon(name: string): Observable<HttpResponse<Blob>>{
    return this.http.get<Blob>(`/api/pokemon/${name}/download`, {observe: 'response', responseType: 'json'});
  }
}
