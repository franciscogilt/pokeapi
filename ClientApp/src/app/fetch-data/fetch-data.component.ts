import { PokemonService } from '../services/pokemon.service';
import { Component } from '@angular/core';
import { saveAs } from "file-saver";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  pokemons: any;
  query: string;
  file: string;

  constructor(private service: PokemonService){};

  ngOnInit(){
    this.service.getPokemon()
    .subscribe(pokemons => this.pokemons = pokemons);
  }

  onSearch(query){
    this.service.getPokemonByName(this.query)
    .subscribe(pokemons => this.pokemons = pokemons);
  }

  onDownload(name){
    this.service.downloadPokemon(name).subscribe(response => {
      const blob = new Blob([JSON.stringify(response.body)], { type: 'text/plain' });
      saveAs(blob, 'MyPokemon.txt');
    });
  }
}
