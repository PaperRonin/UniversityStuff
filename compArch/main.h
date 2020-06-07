struct OFlags {
    int selectedSlot;
    int key;
    int regime;
};

enum regMode { selectingSlot, editingAcum, editingCounter };

struct Editor {
    int selectedDigit;
    int digits[4];
};

struct Editor editor;
struct OFlags outputFlags;