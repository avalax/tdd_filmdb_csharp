declare var $: any;

/// <reference path="api-client.ts" />

namespace filmdb_app {
    
    import FilmDbApiClient = filmdb_api.FilmDbApiClient;
    import Film = filmdb_api.Film;

    export class FilmService {
        private readonly apiClient: FilmDbApiClient;

        constructor(baseUrl: string) {
            this.apiClient = new FilmDbApiClient(baseUrl);
        }

        async getAllFilms(): Promise<Film[]> {
            return await this.apiClient.filmAll();
        }

        async getFilmById(filmId: number): Promise<Film> {
            return await this.apiClient.filmGET(filmId);
        }
    }
}