<template>
  <div class="against">
    <b-container class="bv-example-row">
      <b-row>
        <b-col>
          <div>
            <b-card
              header-tag="header"
              footer-tag="footer"
              class="select-container"
            >
              <template #header>
                <h2>Select an Oponnent</h2>
              </template>
              <b-card-text>
                <b-card-group>
                  <b-card
                    v-for="player in otherPlayers"
                    :key="player.username"
                    :value="player"
                    class="select-card"
                    :img-src="colorPairings[player.color]"
                    img-alt="paddle"
                    img-top
                    @click="
                      opponent = player;
                      opponentNameHasValue = true;
                    "
                  >
                    <b-card-text class="username-text">
                      {{ player.username }}
                    </b-card-text>
                  </b-card>
                </b-card-group>
              </b-card-text>
            </b-card>
          </div>
        </b-col>
        <b-col>
          <div v-if="opponentNameHasValue !== true">
            <b-img :src="Player" class="PlayerImage"></b-img>
          </div>
          <div v-if="opponentNameHasValue">
            <b-card header-tag="header" footer-tag="footer" class="stat-card">
              <template #header>
                <h2>{{ username }} vs {{ opponent.username }}</h2>
              </template>
              <b-card-text>
                <b-container>
                  <b-row>
                    <b-col>
                      <b-row class="mega">Wins</b-row>
                      <b-row class="huge">{{ gamesWon.length }}</b-row>
                    </b-col>
                    <b-col>
                      <b-row class="mega">Losses</b-row>
                      <b-row class="huge">{{ gamesLost.length }}</b-row>
                    </b-col>
                  </b-row>
                  <b-row class="mega">
                    <b-col>Total Games Played</b-col>
                  </b-row>
                  <b-row class="huge">
                    <b-col>{{ totalGamesPlayed }}</b-col>
                  </b-row>
                </b-container>
              </b-card-text>
            </b-card>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
export default {
  props: {
    playerGames: Array,
    username: String,
  },
  data() {
    return {
      opponent: Object,
      opponentNameHasValue: false,
      colorPairings: {
        Red: require("@/images/paddleIconRed.svg"),
        Blue: require("@/images/paddleIconBlue.svg"),
        Green: require("@/images/paddleIconGreen.svg"),
        Orange: require("@/images/paddleIconOrange.svg"),
      },
      Player: require("@/images/Player.svg"),
    };
  },
  computed: {
    otherPlayers: function () {
      let loserNames = this.playerGames
        .filter((games) => {
          return games.winner.username === this.username;
        })
        .map(function (games) {
          return games.loser;
        });
      let winnerNames = this.playerGames
        .filter((games) => {
          return games.loser.username === this.username;
        })
        .map(function (games) {
          return games.winner;
        });
      let allOtherPlayers = loserNames.concat(winnerNames);
      let allUniquePlayers = [];
      for (var i = allOtherPlayers.length - 1; i >= 0; i--) {
        if (
          !allUniquePlayers.some(
            (e) => e.username === allOtherPlayers[i].username
          )
        ) {
          allUniquePlayers.push(allOtherPlayers[i]);
        }
      }
      return allUniquePlayers;
    },
    gamesWon: function () {
      return this.playerGames.filter((item) => {
        return item.loser.username === this.opponent.username;
      });
    },
    gamesLost: function () {
      return this.playerGames.filter((item) => {
        return item.winner.username === this.opponent.username;
      });
    },
    totalPointsWon: function () {
      return this.gamesWon.reduce((memo, game) => memo + game.winnerScore, 0);
    },
    totalPointsLost: function () {
      return this.gamesLost.reduce((memo, game) => memo + game.loserScore, 0);
    },
    totalPoints: function () {
      return this.totalPointsWon + this.totalPointsLost;
    },
    totalGamesPlayed: function () {
      return this.gamesWon.length + this.gamesLost.length;
    },
  },
};
</script>

<style scoped>
.mega {
  font-size: 40px;
  justify-content: center;
}
.huge {
  font-size: 50px;
  justify-content: center;
}
.row {
  margin: 10px 0 10px 0;
}
.hr {
  margin: 0 0 10px 0;
}
img {
  height: 70px;
  min-width: 30%;
  margin: 5px;
}
.paddle-icon-row {
  justify-content: center;
}
.select-card :hover {
  cursor: pointer;
}
.select-card {
  min-width: 33%;
  border: none;
  max-width: 35%;
}
.PlayerImage {
  height: 400px;
}
.username-text {
  font-weight: bold;
}
</style>