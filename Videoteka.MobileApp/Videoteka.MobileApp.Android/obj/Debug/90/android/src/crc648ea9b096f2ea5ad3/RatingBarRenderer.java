package crc648ea9b096f2ea5ad3;


public class RatingBarRenderer
	extends crc643f46942d9dd1fff9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Videoteka.MobileApp.Droid.Renderers.RatingBarRenderer, Videoteka.MobileApp.Android", RatingBarRenderer.class, __md_methods);
	}


	public RatingBarRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("Videoteka.MobileApp.Droid.Renderers.RatingBarRenderer, Videoteka.MobileApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public RatingBarRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("Videoteka.MobileApp.Droid.Renderers.RatingBarRenderer, Videoteka.MobileApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public RatingBarRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == RatingBarRenderer.class)
			mono.android.TypeManager.Activate ("Videoteka.MobileApp.Droid.Renderers.RatingBarRenderer, Videoteka.MobileApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
