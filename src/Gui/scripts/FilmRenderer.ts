declare var $: any;

/// <reference path="api-client.ts" />

namespace filmdb_app {
    
    import Film = filmdb_api.Film;

    export class FilmRenderer {
        private escapeHtml(text: string): string {
            const div = document.createElement('div');
            div.textContent = text;
            return div.innerHTML;
        }

        renderFilmsContainer(films: Film[]): void {
            const container = $('#films-container');
            const filmsList = $('#films-list');

            if (films.length === 0) {
                filmsList.html('<div class="col-12"><p class="text-muted">No films found.</p></div>');
            } else {
                const filmsHtml = films.map(film => this.createFilmCard(film)).join('');
                filmsList.html(filmsHtml);
            }

            container.removeClass('d-none').addClass('fade-in');
            container[0].scrollIntoView({behavior: 'smooth'});
        }

        private createFilmCard(film: Film): string {
            return `
            <div class="col-md-4 mb-3">
                <div class="card film-card h-100">
                    <div class="card-body">
                        <h5 class="card-title">${this.escapeHtml(film.title || '')}</h5>
                        <p class="card-text">
                            <strong>Director:</strong> ${this.escapeHtml(film.director || '')}<br>
                            <strong>Year:</strong> ${film.year}
                        </p>
                        <div class="d-flex justify-content-between align-items-center">
                            <small class="text-muted">ID: ${film.id}</small>
                            <button class="btn btn-outline-primary btn-sm"
                                    onclick="window.app.controller.viewFilmDetails(${film.id})">
                                View Details
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        `;
        }
    }
}