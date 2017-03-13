﻿import {Injectable} from '@angular/core';
import {IMovie} from './movie';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class MovieService {
    private _movieUrl = 'api/movies/movies.json';
    constructor(private _http: Http) { }

    getMovies(): Observable<IMovie[]> {
        return this._http.get(this._movieUrl)
            .map((response: Response) => <IMovie[]>response.json())
            .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    // Added for routing
    getMovie(id: number): Observable<IMovie> {
        return this.getMovies()
            .map((movies: IMovie[]) => movies.find(m => m.movieId === id));
    }

}
