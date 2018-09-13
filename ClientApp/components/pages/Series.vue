<template>
  <div>
    <span v-for="item in series">
      <serie :serieId="item['SerieId']" :title="item['Name']" :description="item['Description']" :imageUrl="item['Image']" ratingValue="4"></serie>
    </span>
     <!--<serie 
      title="Breaking Bad" 
      description="The Story of Walter White" 
      imageUrl="https://images.amcnetworks.com/amc.com/wp-content/uploads/2010/12/breaking-bad-S5-400x600-compressedV1.jpg" 
      ratingValue="4">
     </serie>
     <serie 
     title="Game of thrones" 
     description="You win or you will die" 
     imageUrl="https://img.ricardostatic.ch/t_1000x750/pl/1007486866/0/1/game-of-thrones-poster.jpg" 
     ratingValue="5">
     </serie>-->
  </div>
</template>

<script>
  import serie from '../components/Serie'
  export default {
   components: {
     serie: serie
   },
   data () {
    return {
          series: null
        }
   },
    methods: {
        getCookie: function (name) {
            var value = "; " + document.cookie;
            var parts = value.split("; " + name + "=");
            if (parts.length == 2) return parts.pop().split(";").shift();
        }
    },
   mounted () {
    this.axios.get('https://localhost:5001/api/series', {
        headers: {
            'Authorization': 'Bearer ' + this.getCookie("token")
        }
    }).then((response) => {
        this.series = response.data;
        console.log(response.data);
    })
    }
  }
</script>

<style scoped>

</style>