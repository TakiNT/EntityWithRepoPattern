import DS from "ember-data";

export default DS.Model.extend({
	postId: DS.attr("number"),
	postTitle: DS.attr("string"),
	postExcerpt: DS.attr("string"),
	postContent: DS.attr("string"),
	postImage: DS.attr("string"),
	postTags: DS.attr("string"),
	postDate: DS.attr("date"),
	postAvailable: DS.attr("boolean", {defaultValue: true}),
	postAuthor: DS.attr("string"),

	GetNewestPost: function() {

	} 
});