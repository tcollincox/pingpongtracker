<template>
  <div class='playerStats'>
    <h1>Player Stats</h1>
    <b-container class="formArea">
      <b-col><PlayerSelect/></b-col>
    </b-container>
  </div>
</template>
<script>
import PlayerSelect from '@/components/PlayerSelect.vue'

export default {
  
  components: {
    PlayerSelect
  }
}
</script>

<style scoped>
.playerStats{
    margin: 10px 10px 10px 10px;
    
  }

.playerImage{
    margin: 20px 0px 100px 0px;
  }
h1{
  font-weight: bold;
  font-size:400%;
  margin-top:30px;
  font-family: 'M PLUS Rounded 1c', sans-serif;
}
  
</style>