import DS from 'ember-data';

export default DS.RESTAdapter.extend({
	urlForFindAll: function(modelName){
		var url = this._buildURL(modelName);
		console.log(url + "/GetPosts");
	},
	host: "http://localhost:55882",
	defaultSerializer: "json"
});