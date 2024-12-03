if (!customElements.get('match-card')) {
    class MatchCard extends HTMLElement {
        constructor() {
            super();

            const shadow = this.attachShadow({ mode: 'open' });

            const container = document.createElement('div');
            container.classList.add('match-card');

            const title = document.createElement('h3');
            title.classList.add('match-title');

            const date = document.createElement('p');
            date.classList.add('match-date');

            const homeTeam = this.getAttribute('home-team');
            const awayTeam = this.getAttribute('away-team');
            const matchDate = this.getAttribute('match-date');

            title.textContent = `${homeTeam} vs ${awayTeam}`;
            date.textContent = `Date: ${new Date(matchDate).toLocaleString()}`;

            container.appendChild(title);
            container.appendChild(date);

            const linkElem = document.createElement('link');
            linkElem.setAttribute('rel', 'stylesheet');
            linkElem.setAttribute('href', '/css/components/match-card.css');

            shadow.appendChild(linkElem);
            shadow.appendChild(container);
        }
    }

    customElements.define('match-card', MatchCard);
}