package pl.opole.uni.lista2.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class RodzajUrzadzenia {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer rodzajUrzadzeniaID;
    private String symbol;
    private String nazwa;
    @JsonIgnore
    @OneToMany(mappedBy = "rodzajUrzadzenia")
    private List<Urzadzenie> urzadzenie;

    public Integer getRodzajUrzadzeniaID() {
        return rodzajUrzadzeniaID;
    }

    public void setRodzajUrzadzeniaID(Integer rodzajUrzadzeniaID) {
        this.rodzajUrzadzeniaID = rodzajUrzadzeniaID;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public List<Urzadzenie> getUrzadzenie() {
        return urzadzenie;
    }

    public void setUrzadzenie(List<Urzadzenie> urzadzenie) {
        this.urzadzenie = urzadzenie;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        RodzajUrzadzenia that = (RodzajUrzadzenia) o;
        return Objects.equals(rodzajUrzadzeniaID, that.rodzajUrzadzeniaID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(rodzajUrzadzeniaID);
    }
}
