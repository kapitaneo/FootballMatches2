class LeagueCard extends HTMLElement {
    constructor() {
        super();

        if (!customElements.get('match-card')) {
            const script = document.createElement('script');
            script.src = '/js/components/match-card.js';
            document.head.appendChild(script);
        }

        const shadowRoot = this.attachShadow({ mode: 'open' });

        const container = document.createElement('div');
        container.classList.add('league-container');

        const title = document.createElement('h2');
        title.classList.add('league-title');
        title.textContent = this.getAttribute('league-name');

        let matches = [];

        try {
            matches = JSON.parse(this.getAttribute('matches')) || [];
        } catch (e) {
            console.error("Failed to parse matches attribute:", e);
        }

        container.appendChild(title);

        const carousel = document.createElement('div');
        carousel.classList.add('carousel');

        //Create match cards components
        matches.forEach(match => {
            const matchCard = document.createElement('match-card');
            matchCard.setAttribute('home-team', match.homeTeam?.name || 'Unknown Team');
            matchCard.setAttribute('away-team', match.awayTeam?.name || 'Unknown Team');
            matchCard.setAttribute('match-date', match.utcDate || 'Unknown Date');

            carousel.appendChild(matchCard);
        });

        container.appendChild(carousel);
        shadowRoot.appendChild(container);

        const styleLink = document.createElement('link');
        styleLink.rel = 'stylesheet';
        styleLink.href = '/css/components/league-card.css';
        shadowRoot.appendChild(styleLink);
    }
}

customElements.define('league-card', LeagueCard);