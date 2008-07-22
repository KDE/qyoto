//Auto-generated by kalyptus. DO NOT EDIT.
namespace Nepomuk {
    using Kimono;
    using System;
    using Qyoto;
    using System.Collections.Generic;
    /// <remarks>
    ///  TagWidget provides a simple GUI interface to assign tags.
    ///  It consists of a single text line displaying the assigned 
    ///  tags and a menu to change the tags.
    ///       See <see cref="ITagWidgetSignals"></see> for signals emitted by TagWidget
    /// </remarks>        <short>    TagWidget provides a simple GUI interface to assign tags.</short>
    [SmokeClass("Nepomuk::TagWidget")]
    public class TagWidget : QWidget, IDisposable {
        protected TagWidget(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(TagWidget), this);
        }
        /// <remarks>
        ///  Creates a new TagWidget for resource. The assigned tags are loaded
        ///  instantly.
        ///          </remarks>        <short>    Creates a new TagWidget for resource.</short>
        public TagWidget(Nepomuk.Resource resource, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("TagWidget##", "TagWidget(const Nepomuk::Resource&, QWidget*)", typeof(void), typeof(Nepomuk.Resource), resource, typeof(QWidget), parent);
        }
        public TagWidget(Nepomuk.Resource resource) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("TagWidget#", "TagWidget(const Nepomuk::Resource&)", typeof(void), typeof(Nepomuk.Resource), resource);
        }
        public TagWidget(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("TagWidget#", "TagWidget(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public TagWidget() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("TagWidget", "TagWidget()", typeof(void));
        }
        /// <remarks>
        ///  \return The resources that are supposed to be tagged or an empty
        ///  list if none have been set.
        ///          </remarks>        <short>    \return The resources that are supposed to be tagged or an empty  list if none have been set.</short>
        public List<Nepomuk.Resource> TaggedResources() {
            return (List<Nepomuk.Resource>) interceptor.Invoke("taggedResources", "taggedResources() const", typeof(List<Nepomuk.Resource>));
        }
        /// <remarks>
        ///  \return The list of all tags that are assigned to the currently set 
        ///  resource or an empty list if no resource has been set.
        ///  \sa setTaggedResource, taggedResource, Resource.GetTags
        ///          </remarks>        <short>    \return The list of all tags that are assigned to the currently set   resource or an empty list if no resource has been set.</short>
        public List<Nepomuk.Tag> AssignedTags() {
            return (List<Nepomuk.Tag>) interceptor.Invoke("assignedTags", "assignedTags() const", typeof(List<Nepomuk.Tag>));
        }
        /// <remarks>
        ///  Set the Resource to be tagged. The assigned tags will be loaded
        ///  instantly.
        ///          </remarks>        <short>    Set the Resource to be tagged.</short>
        [Q_SLOT("void setTaggedResource(Resource)")]
        public void SetTaggedResource(Nepomuk.Resource resource) {
            interceptor.Invoke("setTaggedResource#", "setTaggedResource(const Nepomuk::Resource&)", typeof(void), typeof(Nepomuk.Resource), resource);
        }
        [Q_SLOT("void setTaggedResources(QList<Resource>)")]
        public void SetTaggedResources(List<Nepomuk.Resource> resources) {
            interceptor.Invoke("setTaggedResources?", "setTaggedResources(const QList<Nepomuk::Resource>&)", typeof(void), typeof(List<Nepomuk.Resource>), resources);
        }
        /// <remarks>
        ///  Set the list of tags to be assigned to the configured resource.
        ///  If no resource has been set this method does nothing.
        ///  \sa setTaggedResource
        ///          </remarks>        <short>    Set the list of tags to be assigned to the configured resource.</short>
        [Q_SLOT("void setAssignedTags(QList<Tag>)")]
        public void SetAssignedTags(List<Nepomuk.Tag> tags) {
            interceptor.Invoke("setAssignedTags?", "setAssignedTags(const QList<Nepomuk::Tag>&)", typeof(void), typeof(List<Nepomuk.Tag>), tags);
        }
        ~TagWidget() {
            interceptor.Invoke("~TagWidget", "~TagWidget()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~TagWidget", "~TagWidget()", typeof(void));
        }
        protected new ITagWidgetSignals Emit {
            get { return (ITagWidgetSignals) Q_EMIT; }
        }
    }

    public interface ITagWidgetSignals : IQWidgetSignals {
        /// <remarks>
        ///  This signal is emitted whenever a tag is clicked.
        ///          </remarks>        <short>    This signal is emitted whenever a tag is clicked.</short>
        [Q_SIGNAL("void tagClicked(Tag)")]
        void TagClicked(Nepomuk.Tag arg1);
    }
}